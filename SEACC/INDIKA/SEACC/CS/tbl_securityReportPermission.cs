using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire
{
	public sealed class tbl_securityReportPermission {
		#region Fields
		private string user_ID;
		private string report_ID;
		private string companyID;
		private string companyBranch_ID;
		private bool allowPrint;
		private bool allowRePrint;
		private bool allowExport;
		private bool allowView;
		private bool isEnableDefaultPrinter;
		private string createUser_ID;
		private string modifiedUser_ID;
		private string deletedUser_ID;
		private string createTerminal_ID;
		private string modifiedTerminal_ID;
		private string deletedTerminal_ID;
		private DateTime dateCreate;
		private DateTime dateModified;
		private DateTime dateDeleted;
		private bool allowPrintOriginal;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_securityReportPermission class.
		/// </summary>
		public tbl_securityReportPermission() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_securityReportPermission class.
		/// </summary>
		public tbl_securityReportPermission(string user_ID, string report_ID, string companyID, string companyBranch_ID, bool allowPrint, bool allowRePrint, bool allowExport, bool allowView, bool isEnableDefaultPrinter, string createUser_ID, string modifiedUser_ID, string deletedUser_ID, string createTerminal_ID, string modifiedTerminal_ID, string deletedTerminal_ID, DateTime dateCreate, DateTime dateModified, DateTime dateDeleted, bool allowPrintOriginal) {
			this.user_ID = user_ID;
			this.report_ID = report_ID;
			this.companyID = companyID;
			this.companyBranch_ID = companyBranch_ID;
			this.allowPrint = allowPrint;
			this.allowRePrint = allowRePrint;
			this.allowExport = allowExport;
			this.allowView = allowView;
			this.isEnableDefaultPrinter = isEnableDefaultPrinter;
			this.createUser_ID = createUser_ID;
			this.modifiedUser_ID = modifiedUser_ID;
			this.deletedUser_ID = deletedUser_ID;
			this.createTerminal_ID = createTerminal_ID;
			this.modifiedTerminal_ID = modifiedTerminal_ID;
			this.deletedTerminal_ID = deletedTerminal_ID;
			this.dateCreate = dateCreate;
			this.dateModified = dateModified;
			this.dateDeleted = dateDeleted;
			this.allowPrintOriginal = allowPrintOriginal;
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
		/// Gets or sets the Report_ID value.
		/// </summary>
		public string Report_ID {
			get { return report_ID; }
			set { report_ID = value; }
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
		
		/// <summary>
		/// Gets or sets the AllowPrint value.
		/// </summary>
		public bool AllowPrint {
			get { return allowPrint; }
			set { allowPrint = value; }
		}
		
		/// <summary>
		/// Gets or sets the AllowRePrint value.
		/// </summary>
		public bool AllowRePrint {
			get { return allowRePrint; }
			set { allowRePrint = value; }
		}
		
		/// <summary>
		/// Gets or sets the AllowExport value.
		/// </summary>
		public bool AllowExport {
			get { return allowExport; }
			set { allowExport = value; }
		}
		
		/// <summary>
		/// Gets or sets the AllowView value.
		/// </summary>
		public bool AllowView {
			get { return allowView; }
			set { allowView = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsEnableDefaultPrinter value.
		/// </summary>
		public bool IsEnableDefaultPrinter {
			get { return isEnableDefaultPrinter; }
			set { isEnableDefaultPrinter = value; }
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
		/// Gets or sets the DeletedUser_ID value.
		/// </summary>
		public string DeletedUser_ID {
			get { return deletedUser_ID; }
			set { deletedUser_ID = value; }
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
		/// Gets or sets the DateDeleted value.
		/// </summary>
		public DateTime DateDeleted {
			get { return dateDeleted; }
			set { dateDeleted = value; }
		}
		
		/// <summary>
		/// Gets or sets the AllowPrintOriginal value.
		/// </summary>
		public bool AllowPrintOriginal {
			get { return allowPrintOriginal; }
			set { allowPrintOriginal = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_securityReportPermission table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityReportPermissionInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@report_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@allowPrint", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowRePrint", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowExport", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowView", SqlDbType.Bit,1);
			scom.Parameters.Add("@isEnableDefaultPrinter", SqlDbType.Bit,1);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@deletedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@modifiedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@deletedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateDeleted", SqlDbType.DateTime,8);
			scom.Parameters.Add("@allowPrintOriginal", SqlDbType.Bit,1);
 
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@report_ID"].Value = report_ID;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@allowPrint"].Value = allowPrint;
			scom.Parameters["@allowRePrint"].Value = allowRePrint;
			scom.Parameters["@allowExport"].Value = allowExport;
			scom.Parameters["@allowView"].Value = allowView;
			scom.Parameters["@isEnableDefaultPrinter"].Value = isEnableDefaultPrinter;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@deletedUser_ID"].Value = deletedUser_ID;
			scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
			scom.Parameters["@modifiedTerminal_ID"].Value = modifiedTerminal_ID;
			scom.Parameters["@deletedTerminal_ID"].Value = deletedTerminal_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateDeleted"].Value = dateDeleted;
			scom.Parameters["@allowPrintOriginal"].Value = allowPrintOriginal;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_securityReportPermission table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityReportPermissionUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@report_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@allowPrint", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowRePrint", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowExport", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowView", SqlDbType.Bit,1);
			scom.Parameters.Add("@isEnableDefaultPrinter", SqlDbType.Bit,1);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@deletedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@modifiedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@deletedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateDeleted", SqlDbType.DateTime,8);
			scom.Parameters.Add("@allowPrintOriginal", SqlDbType.Bit,1);
 
 
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@report_ID"].Value = report_ID;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@allowPrint"].Value = allowPrint;
			scom.Parameters["@allowRePrint"].Value = allowRePrint;
			scom.Parameters["@allowExport"].Value = allowExport;
			scom.Parameters["@allowView"].Value = allowView;
			scom.Parameters["@isEnableDefaultPrinter"].Value = isEnableDefaultPrinter;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@deletedUser_ID"].Value = deletedUser_ID;
			scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
			scom.Parameters["@modifiedTerminal_ID"].Value = modifiedTerminal_ID;
			scom.Parameters["@deletedTerminal_ID"].Value = deletedTerminal_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateDeleted"].Value = dateDeleted;
			scom.Parameters["@allowPrintOriginal"].Value = allowPrintOriginal;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_securityReportPermission table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityReportPermissionDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@report_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID;
 
			scom.Parameters["@report_ID"].Value = report_ID;
 
			scom.Parameters["@companyID"].Value = companyID;
 
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityReportPermission table by a foreign key.
		/// </summary>
		public static void DeleteAllByReport_ID(string report_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityReportPermissionDeleteAllByReport_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@report_ID", SqlDbType.VarChar,20);
			scom.Parameters["@report_ID"].Value = report_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityReportPermission table by a foreign key.
		/// </summary>
		public static void DeleteAllByUser_ID(string user_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityReportPermissionDeleteAllByUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_securityReportPermission table.
		/// </summary>
		public static tbl_securityReportPermission Select(string user_ID_Incoming, string report_ID_Incoming, string companyID_Incoming, string companyBranch_ID_Incoming){

			tbl_securityReportPermission tbl_securityReportPermissionins = new tbl_securityReportPermission();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityReportPermissionSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@report_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID_Incoming;
			scom.Parameters["@report_ID"].Value = report_ID_Incoming;
			scom.Parameters["@companyID"].Value = companyID_Incoming;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_securityReportPermissionins = Maketbl_securityReportPermission(dataReader);
				} else {
					tbl_securityReportPermissionins = null;
				}
			}
			scon.Close();
			return tbl_securityReportPermissionins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityReportPermission table.
		/// </summary>
		public static List<tbl_securityReportPermission> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityReportPermissionSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_securityReportPermission> tbl_securityReportPermissionList = new List<tbl_securityReportPermission>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityReportPermission tbl_securityReportPermission = Maketbl_securityReportPermission(dataReader);
					tbl_securityReportPermissionList.Add(tbl_securityReportPermission);
				}
			}
			scon.Close();
			return tbl_securityReportPermissionList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityReportPermission table by a foreign key.
		/// </summary>
		public static List<tbl_securityReportPermission> SelectAllByReport_ID(string report_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityReportPermissionSelectAllByReport_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@report_ID", SqlDbType.VarChar,20);
			scom.Parameters["@report_ID"].Value = report_ID;
				List<tbl_securityReportPermission> tbl_securityReportPermissionList = new List<tbl_securityReportPermission>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityReportPermission tbl_securityReportPermission = Maketbl_securityReportPermission(dataReader);
					tbl_securityReportPermissionList.Add(tbl_securityReportPermission);
				}
			}
			scon.Close();
			return tbl_securityReportPermissionList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityReportPermission table by a foreign key.
		/// </summary>
		public static List<tbl_securityReportPermission> SelectAllByUser_ID(string user_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityReportPermissionSelectAllByUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID;
				List<tbl_securityReportPermission> tbl_securityReportPermissionList = new List<tbl_securityReportPermission>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityReportPermission tbl_securityReportPermission = Maketbl_securityReportPermission(dataReader);
					tbl_securityReportPermissionList.Add(tbl_securityReportPermission);
				}
			}
			scon.Close();
			return tbl_securityReportPermissionList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_securityReportPermission class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_securityReportPermission Maketbl_securityReportPermission(SqlDataReader dataReader) {
			tbl_securityReportPermission tbl_securityReportPermission = new tbl_securityReportPermission();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_securityReportPermission.User_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_securityReportPermission.Report_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_securityReportPermission.CompanyID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_securityReportPermission.CompanyBranch_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_securityReportPermission.AllowPrint = dataReader.GetBoolean(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_securityReportPermission.AllowRePrint = dataReader.GetBoolean(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_securityReportPermission.AllowExport = dataReader.GetBoolean(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_securityReportPermission.AllowView = dataReader.GetBoolean(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_securityReportPermission.IsEnableDefaultPrinter = dataReader.GetBoolean(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_securityReportPermission.CreateUser_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_securityReportPermission.ModifiedUser_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_securityReportPermission.DeletedUser_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_securityReportPermission.CreateTerminal_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_securityReportPermission.ModifiedTerminal_ID = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_securityReportPermission.DeletedTerminal_ID = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_securityReportPermission.DateCreate = dataReader.GetDateTime(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_securityReportPermission.DateModified = dataReader.GetDateTime(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_securityReportPermission.DateDeleted = dataReader.GetDateTime(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_securityReportPermission.AllowPrintOriginal = dataReader.GetBoolean(18);
			}

			return tbl_securityReportPermission;
		}
		/// <summary>
		/// This makes tbl_securityReportPermission datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_securityReportPermission object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_securityReportPermission  tbl_securityReportPermission   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_user_ID = new DataColumn("user_ID" , typeof(string));
			DataColumn col_report_ID = new DataColumn("report_ID" , typeof(string));
			DataColumn col_companyID = new DataColumn("companyID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_allowPrint = new DataColumn("allowPrint" , typeof(bool));
			DataColumn col_allowRePrint = new DataColumn("allowRePrint" , typeof(bool));
			DataColumn col_allowExport = new DataColumn("allowExport" , typeof(bool));
			DataColumn col_allowView = new DataColumn("allowView" , typeof(bool));
			DataColumn col_isEnableDefaultPrinter = new DataColumn("isEnableDefaultPrinter" , typeof(bool));
			DataColumn col_createUser_ID = new DataColumn("createUser_ID" , typeof(string));
			DataColumn col_modifiedUser_ID = new DataColumn("modifiedUser_ID" , typeof(string));
			DataColumn col_deletedUser_ID = new DataColumn("deletedUser_ID" , typeof(string));
			DataColumn col_createTerminal_ID = new DataColumn("createTerminal_ID" , typeof(string));
			DataColumn col_modifiedTerminal_ID = new DataColumn("modifiedTerminal_ID" , typeof(string));
			DataColumn col_deletedTerminal_ID = new DataColumn("deletedTerminal_ID" , typeof(string));
			DataColumn col_dateCreate = new DataColumn("dateCreate" , typeof(DateTime));
			DataColumn col_dateModified = new DataColumn("dateModified" , typeof(DateTime));
			DataColumn col_dateDeleted = new DataColumn("dateDeleted" , typeof(DateTime));
			DataColumn col_allowPrintOriginal = new DataColumn("allowPrintOriginal" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_user_ID,col_report_ID,col_companyID,col_companyBranch_ID,col_allowPrint,col_allowRePrint,col_allowExport,col_allowView,col_isEnableDefaultPrinter,col_createUser_ID,col_modifiedUser_ID,col_deletedUser_ID,col_createTerminal_ID,col_modifiedTerminal_ID,col_deletedTerminal_ID,col_dateCreate,col_dateModified,col_dateDeleted,col_allowPrintOriginal,});		return dt;
		}
		/// <summary>
		/// This fills tbl_securityReportPermission datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_securityReportPermission object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_securityReportPermission user) {
		DataRow drow = dt.NewRow();
		
			drow["user_ID"] = user.user_ID;
			drow["report_ID"] = user.report_ID;
			drow["companyID"] = user.companyID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["allowPrint"] = user.allowPrint;
			drow["allowRePrint"] = user.allowRePrint;
			drow["allowExport"] = user.allowExport;
			drow["allowView"] = user.allowView;
			drow["isEnableDefaultPrinter"] = user.isEnableDefaultPrinter;
			drow["createUser_ID"] = user.createUser_ID;
			drow["modifiedUser_ID"] = user.modifiedUser_ID;
			drow["deletedUser_ID"] = user.deletedUser_ID;
			drow["createTerminal_ID"] = user.createTerminal_ID;
			drow["modifiedTerminal_ID"] = user.modifiedTerminal_ID;
			drow["deletedTerminal_ID"] = user.deletedTerminal_ID;
			drow["dateCreate"] = user.dateCreate;
			drow["dateModified"] = user.dateModified;
			drow["dateDeleted"] = user.dateDeleted;
			drow["allowPrintOriginal"] = user.allowPrintOriginal;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
