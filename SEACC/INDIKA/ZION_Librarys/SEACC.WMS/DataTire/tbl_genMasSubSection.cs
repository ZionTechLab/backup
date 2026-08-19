using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genMasSubSection {
		#region Fields
		private string company_ID;
		private string companyBranch_ID;
		private string sectionID;
		private string subSectionID;
		private string subSectionName;
		private string employee_ID_HOSS;
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
		/// Initializes a new instance of the tbl_genMasSubSection class.
		/// </summary>
		public tbl_genMasSubSection() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genMasSubSection class.
		/// </summary>
		public tbl_genMasSubSection(string company_ID, string companyBranch_ID, string sectionID, string subSectionID, string subSectionName, string employee_ID_HOSS, string remarks, bool isCanceled, string userID_Created, string userID_Modified, string userID_Canceled, string terminalID_Created, string terminalID_Modified, string terminalID_Canceled, DateTime date_Created, DateTime date_Modified, DateTime date_Canceled) {
			this.company_ID = company_ID;
			this.companyBranch_ID = companyBranch_ID;
			this.sectionID = sectionID;
			this.subSectionID = subSectionID;
			this.subSectionName = subSectionName;
			this.employee_ID_HOSS = employee_ID_HOSS;
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
		/// Gets or sets the SectionID value.
		/// </summary>
		public string SectionID {
			get { return sectionID; }
			set { sectionID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SubSectionID value.
		/// </summary>
		public string SubSectionID {
			get { return subSectionID; }
			set { subSectionID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SubSectionName value.
		/// </summary>
		public string SubSectionName {
			get { return subSectionName; }
			set { subSectionName = value; }
		}
		
		/// <summary>
		/// Gets or sets the Employee_ID_HOSS value.
		/// </summary>
		public string Employee_ID_HOSS {
			get { return employee_ID_HOSS; }
			set { employee_ID_HOSS = value; }
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
		/// Saves a record to the tbl_genMasSubSection table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasSubSectionInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@sectionID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@subSectionID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@subSectionName", SqlDbType.VarChar,100);
			scom.Parameters.Add("@employee_ID_HOSS", SqlDbType.VarChar,20);
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
			scom.Parameters["@sectionID"].Value = sectionID;
			scom.Parameters["@subSectionID"].Value = subSectionID;
			scom.Parameters["@subSectionName"].Value = subSectionName;
			scom.Parameters["@employee_ID_HOSS"].Value = employee_ID_HOSS;
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
		/// Updates a record in the tbl_genMasSubSection table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasSubSectionUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@sectionID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@subSectionID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@subSectionName", SqlDbType.VarChar,100);
			scom.Parameters.Add("@employee_ID_HOSS", SqlDbType.VarChar,20);
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
			scom.Parameters["@sectionID"].Value = sectionID;
			scom.Parameters["@subSectionID"].Value = subSectionID;
			scom.Parameters["@subSectionName"].Value = subSectionName;
			scom.Parameters["@employee_ID_HOSS"].Value = employee_ID_HOSS;
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
		/// Deletes a record from the tbl_genMasSubSection table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasSubSectionDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@sectionID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@subSectionID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters["@sectionID"].Value = sectionID;
 
			scom.Parameters["@subSectionID"].Value = subSectionID;
 
			scom.Parameters["@company_ID"].Value = company_ID;
 
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMasSubSection table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompany_ID_CompanyBranch_ID(string company_ID, string companyBranch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasSubSectionDeleteAllByCompany_ID_CompanyBranch_ID", scon);
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
		/// Selects all records from the tbl_genMasSubSection table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompany_ID(string company_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasSubSectionDeleteAllByCompany_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters["@company_ID"].Value = company_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genMasSubSection table.
		/// </summary>
		public static tbl_genMasSubSection Select(string sectionID_Incoming, string subSectionID_Incoming, string company_ID_Incoming, string companyBranch_ID_Incoming)
        {

			tbl_genMasSubSection tbl_genMasSubSectionins = new tbl_genMasSubSection();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasSubSectionSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@sectionID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@subSectionID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters["@sectionID"].Value = sectionID_Incoming;
			scom.Parameters["@subSectionID"].Value = subSectionID_Incoming;
			scom.Parameters["@company_ID"].Value = company_ID_Incoming;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genMasSubSectionins = Maketbl_genMasSubSection(dataReader);
				} else {
					tbl_genMasSubSectionins = null;
				}
			}
			scon.Close();
			return tbl_genMasSubSectionins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMasSubSection table.
		/// </summary>
		public static List<tbl_genMasSubSection> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasSubSectionSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genMasSubSection> tbl_genMasSubSectionList = new List<tbl_genMasSubSection>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genMasSubSection tbl_genMasSubSection = Maketbl_genMasSubSection(dataReader);
					tbl_genMasSubSectionList.Add(tbl_genMasSubSection);
				}
			}
			scon.Close();
			return tbl_genMasSubSectionList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMasSubSection table by a foreign key.
		/// </summary>
		public static List<tbl_genMasSubSection> SelectAllByCompany_ID_CompanyBranch_ID(string company_ID, string companyBranch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasSubSectionSelectAllByCompany_ID_CompanyBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
				List<tbl_genMasSubSection> tbl_genMasSubSectionList = new List<tbl_genMasSubSection>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genMasSubSection tbl_genMasSubSection = Maketbl_genMasSubSection(dataReader);
					tbl_genMasSubSectionList.Add(tbl_genMasSubSection);
				}
			}
			scon.Close();
			return tbl_genMasSubSectionList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMasSubSection table by a foreign key.
		/// </summary>
		public static List<tbl_genMasSubSection> SelectAllByCompany_ID(string company_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasSubSectionSelectAllByCompany_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters["@company_ID"].Value = company_ID;
				List<tbl_genMasSubSection> tbl_genMasSubSectionList = new List<tbl_genMasSubSection>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genMasSubSection tbl_genMasSubSection = Maketbl_genMasSubSection(dataReader);
					tbl_genMasSubSectionList.Add(tbl_genMasSubSection);
				}
			}
			scon.Close();
			return tbl_genMasSubSectionList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genMasSubSection class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genMasSubSection Maketbl_genMasSubSection(SqlDataReader dataReader) {
			tbl_genMasSubSection tbl_genMasSubSection = new tbl_genMasSubSection();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genMasSubSection.Company_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genMasSubSection.CompanyBranch_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genMasSubSection.SectionID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_genMasSubSection.SubSectionID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_genMasSubSection.SubSectionName = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_genMasSubSection.Employee_ID_HOSS = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_genMasSubSection.Remarks = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_genMasSubSection.IsCanceled = dataReader.GetBoolean(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_genMasSubSection.UserID_Created = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_genMasSubSection.UserID_Modified = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_genMasSubSection.UserID_Canceled = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_genMasSubSection.TerminalID_Created = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_genMasSubSection.TerminalID_Modified = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_genMasSubSection.TerminalID_Canceled = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_genMasSubSection.Date_Created = dataReader.GetDateTime(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_genMasSubSection.Date_Modified = dataReader.GetDateTime(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_genMasSubSection.Date_Canceled = dataReader.GetDateTime(16);
			}

			return tbl_genMasSubSection;
		}
		/// <summary>
		/// This makes tbl_genMasSubSection datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genMasSubSection object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genMasSubSection  tbl_genMasSubSection   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_company_ID = new DataColumn("company_ID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_sectionID = new DataColumn("sectionID" , typeof(string));
			DataColumn col_subSectionID = new DataColumn("subSectionID" , typeof(string));
			DataColumn col_subSectionName = new DataColumn("subSectionName" , typeof(string));
			DataColumn col_employee_ID_HOSS = new DataColumn("employee_ID_HOSS" , typeof(string));
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
		dt.Columns.AddRange(new DataColumn[] { col_company_ID,col_companyBranch_ID,col_sectionID,col_subSectionID,col_subSectionName,col_employee_ID_HOSS,col_remarks,col_isCanceled,col_userID_Created,col_userID_Modified,col_userID_Canceled,col_terminalID_Created,col_terminalID_Modified,col_terminalID_Canceled,col_date_Created,col_date_Modified,col_date_Canceled,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genMasSubSection datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genMasSubSection object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genMasSubSection user) {
		DataRow drow = dt.NewRow();
		
			drow["company_ID"] = user.company_ID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["sectionID"] = user.sectionID;
			drow["subSectionID"] = user.subSectionID;
			drow["subSectionName"] = user.subSectionName;
			drow["employee_ID_HOSS"] = user.employee_ID_HOSS;
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
