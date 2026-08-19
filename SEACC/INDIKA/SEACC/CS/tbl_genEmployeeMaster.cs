using DataTire;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire
{
	public sealed class tbl_genEmployeeMaster {
		#region Fields
		private string employee_ID;
		private string employeeName;
		private string designation;
		private string nicNo;
		private string employeCode;
		private string telephone;
		private string mobile;
		private string fax;
		private string email;
		private string gl_ID;
		private DateTime dateOfBirth;
		private bool isSalesManager;
		private bool isAreaManager;
		private bool isSelesRep;
		private bool isSalesExecutive;
		private bool isDriver;
		private bool isAssistant;
		private bool isDelete;
		private decimal employeeCostPerHour;
		private bool isOperator;
		private decimal salesTarget;
		private decimal commisionPersentage_Normal;
		private decimal commisionPersentage_Bones;
		private decimal minimumSalesTarget;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genEmployeeMaster class.
		/// </summary>
		public tbl_genEmployeeMaster() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genEmployeeMaster class.
		/// </summary>
		public tbl_genEmployeeMaster(string employee_ID, string employeeName, string designation, string nicNo, string employeCode, string telephone, string mobile, string fax, string email, string gl_ID, DateTime dateOfBirth, bool isSalesManager, bool isAreaManager, bool isSelesRep, bool isSalesExecutive, bool isDriver, bool isAssistant, bool isDelete, decimal employeeCostPerHour, bool isOperator, decimal salesTarget, decimal commisionPersentage_Normal, decimal commisionPersentage_Bones, decimal minimumSalesTarget) {
			this.employee_ID = employee_ID;
			this.employeeName = employeeName;
			this.designation = designation;
			this.nicNo = nicNo;
			this.employeCode = employeCode;
			this.telephone = telephone;
			this.mobile = mobile;
			this.fax = fax;
			this.email = email;
			this.gl_ID = gl_ID;
			this.dateOfBirth = dateOfBirth;
			this.isSalesManager = isSalesManager;
			this.isAreaManager = isAreaManager;
			this.isSelesRep = isSelesRep;
			this.isSalesExecutive = isSalesExecutive;
			this.isDriver = isDriver;
			this.isAssistant = isAssistant;
			this.isDelete = isDelete;
			this.employeeCostPerHour = employeeCostPerHour;
			this.isOperator = isOperator;
			this.salesTarget = salesTarget;
			this.commisionPersentage_Normal = commisionPersentage_Normal;
			this.commisionPersentage_Bones = commisionPersentage_Bones;
			this.minimumSalesTarget = minimumSalesTarget;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Employee_ID value.
		/// </summary>
		public string Employee_ID {
			get { return employee_ID; }
			set { employee_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the EmployeeName value.
		/// </summary>
		public string EmployeeName {
			get { return employeeName; }
			set { employeeName = value; }
		}
		
		/// <summary>
		/// Gets or sets the Designation value.
		/// </summary>
		public string Designation {
			get { return designation; }
			set { designation = value; }
		}
		
		/// <summary>
		/// Gets or sets the NicNo value.
		/// </summary>
		public string NicNo {
			get { return nicNo; }
			set { nicNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the EmployeCode value.
		/// </summary>
		public string EmployeCode {
			get { return employeCode; }
			set { employeCode = value; }
		}
		
		/// <summary>
		/// Gets or sets the Telephone value.
		/// </summary>
		public string Telephone {
			get { return telephone; }
			set { telephone = value; }
		}
		
		/// <summary>
		/// Gets or sets the Mobile value.
		/// </summary>
		public string Mobile {
			get { return mobile; }
			set { mobile = value; }
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
		/// Gets or sets the Gl_ID value.
		/// </summary>
		public string Gl_ID {
			get { return gl_ID; }
			set { gl_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateOfBirth value.
		/// </summary>
		public DateTime DateOfBirth {
			get { return dateOfBirth; }
			set { dateOfBirth = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSalesManager value.
		/// </summary>
		public bool IsSalesManager {
			get { return isSalesManager; }
			set { isSalesManager = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsAreaManager value.
		/// </summary>
		public bool IsAreaManager {
			get { return isAreaManager; }
			set { isAreaManager = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSelesRep value.
		/// </summary>
		public bool IsSelesRep {
			get { return isSelesRep; }
			set { isSelesRep = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSalesExecutive value.
		/// </summary>
		public bool IsSalesExecutive {
			get { return isSalesExecutive; }
			set { isSalesExecutive = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsDriver value.
		/// </summary>
		public bool IsDriver {
			get { return isDriver; }
			set { isDriver = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsAssistant value.
		/// </summary>
		public bool IsAssistant {
			get { return isAssistant; }
			set { isAssistant = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsDelete value.
		/// </summary>
		public bool IsDelete {
			get { return isDelete; }
			set { isDelete = value; }
		}
		
		/// <summary>
		/// Gets or sets the EmployeeCostPerHour value.
		/// </summary>
		public decimal EmployeeCostPerHour {
			get { return employeeCostPerHour; }
			set { employeeCostPerHour = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsOperator value.
		/// </summary>
		public bool IsOperator {
			get { return isOperator; }
			set { isOperator = value; }
		}
		
		/// <summary>
		/// Gets or sets the SalesTarget value.
		/// </summary>
		public decimal SalesTarget {
			get { return salesTarget; }
			set { salesTarget = value; }
		}
		
		/// <summary>
		/// Gets or sets the CommisionPersentage_Normal value.
		/// </summary>
		public decimal CommisionPersentage_Normal {
			get { return commisionPersentage_Normal; }
			set { commisionPersentage_Normal = value; }
		}
		
		/// <summary>
		/// Gets or sets the CommisionPersentage_Bones value.
		/// </summary>
		public decimal CommisionPersentage_Bones {
			get { return commisionPersentage_Bones; }
			set { commisionPersentage_Bones = value; }
		}
		
		/// <summary>
		/// Gets or sets the MinimumSalesTarget value.
		/// </summary>
		public decimal MinimumSalesTarget {
			get { return minimumSalesTarget; }
			set { minimumSalesTarget = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_genEmployeeMaster table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genEmployeeMasterInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@employeeName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@designation", SqlDbType.VarChar,50);
			scom.Parameters.Add("@nicNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@employeCode", SqlDbType.VarChar,50);
			scom.Parameters.Add("@telephone", SqlDbType.VarChar,50);
			scom.Parameters.Add("@mobile", SqlDbType.VarChar,50);
			scom.Parameters.Add("@fax", SqlDbType.VarChar,50);
			scom.Parameters.Add("@email", SqlDbType.VarChar,50);
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateOfBirth", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isSalesManager", SqlDbType.Bit,1);
			scom.Parameters.Add("@isAreaManager", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSelesRep", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSalesExecutive", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDriver", SqlDbType.Bit,1);
			scom.Parameters.Add("@isAssistant", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDelete", SqlDbType.Bit,1);
			scom.Parameters.Add("@employeeCostPerHour", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isOperator", SqlDbType.Bit,1);
			scom.Parameters.Add("@salesTarget", SqlDbType.Decimal,9);
			scom.Parameters.Add("@commisionPersentage_Normal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@commisionPersentage_Bones", SqlDbType.Decimal,9);
			scom.Parameters.Add("@minimumSalesTarget", SqlDbType.Decimal,9);
 
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@employeeName"].Value = employeeName;
			scom.Parameters["@designation"].Value = designation;
			scom.Parameters["@nicNo"].Value = nicNo;
			scom.Parameters["@employeCode"].Value = employeCode;
			scom.Parameters["@telephone"].Value = telephone;
			scom.Parameters["@mobile"].Value = mobile;
			scom.Parameters["@fax"].Value = fax;
			scom.Parameters["@email"].Value = email;
			scom.Parameters["@gl_ID"].Value = gl_ID;
			scom.Parameters["@dateOfBirth"].Value = dateOfBirth;
			scom.Parameters["@isSalesManager"].Value = isSalesManager;
			scom.Parameters["@isAreaManager"].Value = isAreaManager;
			scom.Parameters["@isSelesRep"].Value = isSelesRep;
			scom.Parameters["@isSalesExecutive"].Value = isSalesExecutive;
			scom.Parameters["@isDriver"].Value = isDriver;
			scom.Parameters["@isAssistant"].Value = isAssistant;
			scom.Parameters["@isDelete"].Value = isDelete;
			scom.Parameters["@employeeCostPerHour"].Value = employeeCostPerHour;
			scom.Parameters["@isOperator"].Value = isOperator;
			scom.Parameters["@salesTarget"].Value = salesTarget;
			scom.Parameters["@commisionPersentage_Normal"].Value = commisionPersentage_Normal;
			scom.Parameters["@commisionPersentage_Bones"].Value = commisionPersentage_Bones;
			scom.Parameters["@minimumSalesTarget"].Value = minimumSalesTarget;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genEmployeeMaster table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genEmployeeMasterUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@employeeName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@designation", SqlDbType.VarChar,50);
			scom.Parameters.Add("@nicNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@employeCode", SqlDbType.VarChar,50);
			scom.Parameters.Add("@telephone", SqlDbType.VarChar,50);
			scom.Parameters.Add("@mobile", SqlDbType.VarChar,50);
			scom.Parameters.Add("@fax", SqlDbType.VarChar,50);
			scom.Parameters.Add("@email", SqlDbType.VarChar,50);
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateOfBirth", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isSalesManager", SqlDbType.Bit,1);
			scom.Parameters.Add("@isAreaManager", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSelesRep", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSalesExecutive", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDriver", SqlDbType.Bit,1);
			scom.Parameters.Add("@isAssistant", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDelete", SqlDbType.Bit,1);
			scom.Parameters.Add("@employeeCostPerHour", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isOperator", SqlDbType.Bit,1);
			scom.Parameters.Add("@salesTarget", SqlDbType.Decimal,9);
			scom.Parameters.Add("@commisionPersentage_Normal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@commisionPersentage_Bones", SqlDbType.Decimal,9);
			scom.Parameters.Add("@minimumSalesTarget", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@employeeName"].Value = employeeName;
			scom.Parameters["@designation"].Value = designation;
			scom.Parameters["@nicNo"].Value = nicNo;
			scom.Parameters["@employeCode"].Value = employeCode;
			scom.Parameters["@telephone"].Value = telephone;
			scom.Parameters["@mobile"].Value = mobile;
			scom.Parameters["@fax"].Value = fax;
			scom.Parameters["@email"].Value = email;
			scom.Parameters["@gl_ID"].Value = gl_ID;
			scom.Parameters["@dateOfBirth"].Value = dateOfBirth;
			scom.Parameters["@isSalesManager"].Value = isSalesManager;
			scom.Parameters["@isAreaManager"].Value = isAreaManager;
			scom.Parameters["@isSelesRep"].Value = isSelesRep;
			scom.Parameters["@isSalesExecutive"].Value = isSalesExecutive;
			scom.Parameters["@isDriver"].Value = isDriver;
			scom.Parameters["@isAssistant"].Value = isAssistant;
			scom.Parameters["@isDelete"].Value = isDelete;
			scom.Parameters["@employeeCostPerHour"].Value = employeeCostPerHour;
			scom.Parameters["@isOperator"].Value = isOperator;
			scom.Parameters["@salesTarget"].Value = salesTarget;
			scom.Parameters["@commisionPersentage_Normal"].Value = commisionPersentage_Normal;
			scom.Parameters["@commisionPersentage_Bones"].Value = commisionPersentage_Bones;
			scom.Parameters["@minimumSalesTarget"].Value = minimumSalesTarget;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genEmployeeMaster table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genEmployeeMasterDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@employee_ID"].Value = employee_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genEmployeeMaster table.
		/// </summary>
		public static tbl_genEmployeeMaster Select(string employee_ID_Incoming){

			tbl_genEmployeeMaster tbl_genEmployeeMasterins = new tbl_genEmployeeMaster();
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genEmployeeMasterSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@employee_ID"].Value = employee_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genEmployeeMasterins = Maketbl_genEmployeeMaster(dataReader);
				} else {
					tbl_genEmployeeMasterins = null;
				}
			}
			scon.Close();
			return tbl_genEmployeeMasterins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genEmployeeMaster table.
		/// </summary>
		public static List<tbl_genEmployeeMaster> SelectAll() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genEmployeeMasterSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genEmployeeMaster> tbl_genEmployeeMasterList = new List<tbl_genEmployeeMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genEmployeeMaster tbl_genEmployeeMaster = Maketbl_genEmployeeMaster(dataReader);
					tbl_genEmployeeMasterList.Add(tbl_genEmployeeMaster);
				}
			}
			scon.Close();
			return tbl_genEmployeeMasterList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genEmployeeMaster class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genEmployeeMaster Maketbl_genEmployeeMaster(SqlDataReader dataReader) {
			tbl_genEmployeeMaster tbl_genEmployeeMaster = new tbl_genEmployeeMaster();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genEmployeeMaster.Employee_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genEmployeeMaster.EmployeeName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genEmployeeMaster.Designation = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_genEmployeeMaster.NicNo = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_genEmployeeMaster.EmployeCode = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_genEmployeeMaster.Telephone = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_genEmployeeMaster.Mobile = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_genEmployeeMaster.Fax = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_genEmployeeMaster.Email = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_genEmployeeMaster.Gl_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_genEmployeeMaster.DateOfBirth = dataReader.GetDateTime(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_genEmployeeMaster.IsSalesManager = dataReader.GetBoolean(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_genEmployeeMaster.IsAreaManager = dataReader.GetBoolean(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_genEmployeeMaster.IsSelesRep = dataReader.GetBoolean(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_genEmployeeMaster.IsSalesExecutive = dataReader.GetBoolean(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_genEmployeeMaster.IsDriver = dataReader.GetBoolean(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_genEmployeeMaster.IsAssistant = dataReader.GetBoolean(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_genEmployeeMaster.IsDelete = dataReader.GetBoolean(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_genEmployeeMaster.EmployeeCostPerHour = dataReader.GetDecimal(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_genEmployeeMaster.IsOperator = dataReader.GetBoolean(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_genEmployeeMaster.SalesTarget = dataReader.GetDecimal(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_genEmployeeMaster.CommisionPersentage_Normal = dataReader.GetDecimal(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_genEmployeeMaster.CommisionPersentage_Bones = dataReader.GetDecimal(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_genEmployeeMaster.MinimumSalesTarget = dataReader.GetDecimal(23);
			}

			return tbl_genEmployeeMaster;
		}
		/// <summary>
		/// This makes tbl_genEmployeeMaster datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genEmployeeMaster object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genEmployeeMaster  tbl_genEmployeeMaster   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_employee_ID = new DataColumn("employee_ID" , typeof(string));
			DataColumn col_employeeName = new DataColumn("employeeName" , typeof(string));
			DataColumn col_designation = new DataColumn("designation" , typeof(string));
			DataColumn col_nicNo = new DataColumn("nicNo" , typeof(string));
			DataColumn col_employeCode = new DataColumn("employeCode" , typeof(string));
			DataColumn col_telephone = new DataColumn("telephone" , typeof(string));
			DataColumn col_mobile = new DataColumn("mobile" , typeof(string));
			DataColumn col_fax = new DataColumn("fax" , typeof(string));
			DataColumn col_email = new DataColumn("email" , typeof(string));
			DataColumn col_gl_ID = new DataColumn("gl_ID" , typeof(string));
			DataColumn col_dateOfBirth = new DataColumn("dateOfBirth" , typeof(DateTime));
			DataColumn col_isSalesManager = new DataColumn("isSalesManager" , typeof(bool));
			DataColumn col_isAreaManager = new DataColumn("isAreaManager" , typeof(bool));
			DataColumn col_isSelesRep = new DataColumn("isSelesRep" , typeof(bool));
			DataColumn col_isSalesExecutive = new DataColumn("isSalesExecutive" , typeof(bool));
			DataColumn col_isDriver = new DataColumn("isDriver" , typeof(bool));
			DataColumn col_isAssistant = new DataColumn("isAssistant" , typeof(bool));
			DataColumn col_isDelete = new DataColumn("isDelete" , typeof(bool));
			DataColumn col_employeeCostPerHour = new DataColumn("employeeCostPerHour" , typeof(decimal));
			DataColumn col_isOperator = new DataColumn("isOperator" , typeof(bool));
			DataColumn col_salesTarget = new DataColumn("salesTarget" , typeof(decimal));
			DataColumn col_commisionPersentage_Normal = new DataColumn("commisionPersentage_Normal" , typeof(decimal));
			DataColumn col_commisionPersentage_Bones = new DataColumn("commisionPersentage_Bones" , typeof(decimal));
			DataColumn col_minimumSalesTarget = new DataColumn("minimumSalesTarget" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_employee_ID,col_employeeName,col_designation,col_nicNo,col_employeCode,col_telephone,col_mobile,col_fax,col_email,col_gl_ID,col_dateOfBirth,col_isSalesManager,col_isAreaManager,col_isSelesRep,col_isSalesExecutive,col_isDriver,col_isAssistant,col_isDelete,col_employeeCostPerHour,col_isOperator,col_salesTarget,col_commisionPersentage_Normal,col_commisionPersentage_Bones,col_minimumSalesTarget,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genEmployeeMaster datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genEmployeeMaster object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genEmployeeMaster user) {
		DataRow drow = dt.NewRow();
		
			drow["employee_ID"] = user.employee_ID;
			drow["employeeName"] = user.employeeName;
			drow["designation"] = user.designation;
			drow["nicNo"] = user.nicNo;
			drow["employeCode"] = user.employeCode;
			drow["telephone"] = user.telephone;
			drow["mobile"] = user.mobile;
			drow["fax"] = user.fax;
			drow["email"] = user.email;
			drow["gl_ID"] = user.gl_ID;
			drow["dateOfBirth"] = user.dateOfBirth;
			drow["isSalesManager"] = user.isSalesManager;
			drow["isAreaManager"] = user.isAreaManager;
			drow["isSelesRep"] = user.isSelesRep;
			drow["isSalesExecutive"] = user.isSalesExecutive;
			drow["isDriver"] = user.isDriver;
			drow["isAssistant"] = user.isAssistant;
			drow["isDelete"] = user.isDelete;
			drow["employeeCostPerHour"] = user.employeeCostPerHour;
			drow["isOperator"] = user.isOperator;
			drow["salesTarget"] = user.salesTarget;
			drow["commisionPersentage_Normal"] = user.commisionPersentage_Normal;
			drow["commisionPersentage_Bones"] = user.commisionPersentage_Bones;
			drow["minimumSalesTarget"] = user.minimumSalesTarget;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
