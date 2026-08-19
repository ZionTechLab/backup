using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_securityFunctionMaster_Report_Advanced {
		#region Fields
		private int line_No;
		private int function_ID;
		private string companyID;
		private string companyBranch_ID;
		private bool isDefault;
		private string reportPath;
		private string remarks;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_securityFunctionMaster_Report_Advanced class.
		/// </summary>
		public tbl_securityFunctionMaster_Report_Advanced() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_securityFunctionMaster_Report_Advanced class.
		/// </summary>
		public tbl_securityFunctionMaster_Report_Advanced(int line_No, int function_ID, string companyID, string companyBranch_ID, bool isDefault, string reportPath, string remarks) {
			this.line_No = line_No;
			this.function_ID = function_ID;
			this.companyID = companyID;
			this.companyBranch_ID = companyBranch_ID;
			this.isDefault = isDefault;
			this.reportPath = reportPath;
			this.remarks = remarks;
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
		/// Gets or sets the Function_ID value.
		/// </summary>
		public int Function_ID {
			get { return function_ID; }
			set { function_ID = value; }
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
		/// Gets or sets the IsDefault value.
		/// </summary>
		public bool IsDefault {
			get { return isDefault; }
			set { isDefault = value; }
		}
		
		/// <summary>
		/// Gets or sets the ReportPath value.
		/// </summary>
		public string ReportPath {
			get { return reportPath; }
			set { reportPath = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remarks value.
		/// </summary>
		public string Remarks {
			get { return remarks; }
			set { remarks = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_securityFunctionMaster_Report_Advanced table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionMaster_Report_AdvancedInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@function_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isDefault", SqlDbType.Bit,1);
			scom.Parameters.Add("@reportPath", SqlDbType.VarChar,700);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,500);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@function_ID"].Value = function_ID;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@isDefault"].Value = isDefault;
			scom.Parameters["@reportPath"].Value = reportPath;
			scom.Parameters["@remarks"].Value = remarks;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_securityFunctionMaster_Report_Advanced table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionMaster_Report_AdvancedUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@function_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isDefault", SqlDbType.Bit,1);
			scom.Parameters.Add("@reportPath", SqlDbType.VarChar,700);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,500);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@function_ID"].Value = function_ID;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@isDefault"].Value = isDefault;
			scom.Parameters["@reportPath"].Value = reportPath;
			scom.Parameters["@remarks"].Value = remarks;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_securityFunctionMaster_Report_Advanced table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionMaster_Report_AdvancedDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@function_ID", SqlDbType.Int,4);
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@function_ID"].Value = function_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityFunctionMaster_Report_Advanced table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyID(string companyID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionMaster_Report_AdvancedDeleteAllByCompanyID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters["@companyID"].Value = companyID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityFunctionMaster_Report_Advanced table by a foreign key.
		/// </summary>
		public static void DeleteAllByFunction_ID(int function_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionMaster_Report_AdvancedDeleteAllByFunction_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@function_ID", SqlDbType.Int,4);
			scom.Parameters["@function_ID"].Value = function_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityFunctionMaster_Report_Advanced table by a foreign key.
		/// </summary>
		//public static void DeleteAllByFunction_ID(int function_ID) {
 
		//	SqlConnection scon = DBHandling.GetConnection();
		//	SqlCommand scom = new SqlCommand("tbl_securityFunctionMaster_Report_AdvancedDeleteAllByFunction_ID", scon);
		//	scom.CommandType = CommandType.StoredProcedure;
		//	scon.Open();
 
		//	scom.Parameters.Add("@function_ID", SqlDbType.Int,4);
		//	scom.Parameters["@function_ID"].Value = function_ID;
 
		//	scon.Open();
		//	scom.ExecuteNonQuery();
		//	scon.Close();
		//}
		
		/// <summary>
		/// Selects all records from the tbl_securityFunctionMaster_Report_Advanced table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyBranch_ID(string companyBranch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionMaster_Report_AdvancedDeleteAllByCompanyBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_securityFunctionMaster_Report_Advanced table.
		/// </summary>
		public static tbl_securityFunctionMaster_Report_Advanced Select(int line_No_Incoming, int function_ID_Incoming){

			tbl_securityFunctionMaster_Report_Advanced tbl_securityFunctionMaster_Report_Advancedins = new tbl_securityFunctionMaster_Report_Advanced();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionMaster_Report_AdvancedSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@function_ID", SqlDbType.Int,4);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@function_ID"].Value = function_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_securityFunctionMaster_Report_Advancedins = Maketbl_securityFunctionMaster_Report_Advanced(dataReader);
				} else {
					tbl_securityFunctionMaster_Report_Advancedins = null;
				}
			}
			scon.Close();
			return tbl_securityFunctionMaster_Report_Advancedins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityFunctionMaster_Report_Advanced table.
		/// </summary>
		public static List<tbl_securityFunctionMaster_Report_Advanced> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionMaster_Report_AdvancedSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_securityFunctionMaster_Report_Advanced> tbl_securityFunctionMaster_Report_AdvancedList = new List<tbl_securityFunctionMaster_Report_Advanced>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityFunctionMaster_Report_Advanced tbl_securityFunctionMaster_Report_Advanced = Maketbl_securityFunctionMaster_Report_Advanced(dataReader);
					tbl_securityFunctionMaster_Report_AdvancedList.Add(tbl_securityFunctionMaster_Report_Advanced);
				}
			}
			scon.Close();
			return tbl_securityFunctionMaster_Report_AdvancedList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityFunctionMaster_Report_Advanced table by a foreign key.
		/// </summary>
		public static List<tbl_securityFunctionMaster_Report_Advanced> SelectAllByCompanyID(string companyID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionMaster_Report_AdvancedSelectAllByCompanyID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters["@companyID"].Value = companyID;
				List<tbl_securityFunctionMaster_Report_Advanced> tbl_securityFunctionMaster_Report_AdvancedList = new List<tbl_securityFunctionMaster_Report_Advanced>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityFunctionMaster_Report_Advanced tbl_securityFunctionMaster_Report_Advanced = Maketbl_securityFunctionMaster_Report_Advanced(dataReader);
					tbl_securityFunctionMaster_Report_AdvancedList.Add(tbl_securityFunctionMaster_Report_Advanced);
				}
			}
			scon.Close();
			return tbl_securityFunctionMaster_Report_AdvancedList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityFunctionMaster_Report_Advanced table by a foreign key.
		/// </summary>
		public static List<tbl_securityFunctionMaster_Report_Advanced> SelectAllByFunction_ID(int function_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionMaster_Report_AdvancedSelectAllByFunction_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@function_ID", SqlDbType.Int,4);
			scom.Parameters["@function_ID"].Value = function_ID;
				List<tbl_securityFunctionMaster_Report_Advanced> tbl_securityFunctionMaster_Report_AdvancedList = new List<tbl_securityFunctionMaster_Report_Advanced>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityFunctionMaster_Report_Advanced tbl_securityFunctionMaster_Report_Advanced = Maketbl_securityFunctionMaster_Report_Advanced(dataReader);
					tbl_securityFunctionMaster_Report_AdvancedList.Add(tbl_securityFunctionMaster_Report_Advanced);
				}
			}
			scon.Close();
			return tbl_securityFunctionMaster_Report_AdvancedList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityFunctionMaster_Report_Advanced table by a foreign key.
		/// </summary>
		//public static List<tbl_securityFunctionMaster_Report_Advanced> SelectAllByFunction_ID(int function_ID) {
 
		//	SqlConnection scon = DBHandling.GetConnection();
		//	SqlCommand scom = new SqlCommand("tbl_securityFunctionMaster_Report_AdvancedSelectAllByFunction_ID", scon);
		//	scom.CommandType = CommandType.StoredProcedure;
		//	scon.Open();
 
		//	scom.Parameters.Add("@function_ID", SqlDbType.Int,4);
		//	scom.Parameters["@function_ID"].Value = function_ID;
		//		List<tbl_securityFunctionMaster_Report_Advanced> tbl_securityFunctionMaster_Report_AdvancedList = new List<tbl_securityFunctionMaster_Report_Advanced>();
		//	using (SqlDataReader dataReader = scom.ExecuteReader()){
		//		while (dataReader.Read()) {
		//			tbl_securityFunctionMaster_Report_Advanced tbl_securityFunctionMaster_Report_Advanced = Maketbl_securityFunctionMaster_Report_Advanced(dataReader);
		//			tbl_securityFunctionMaster_Report_AdvancedList.Add(tbl_securityFunctionMaster_Report_Advanced);
		//		}
		//	}
		//	scon.Close();
		//	return tbl_securityFunctionMaster_Report_AdvancedList;
		//}
		
		/// <summary>
		/// Selects all records from the tbl_securityFunctionMaster_Report_Advanced table by a foreign key.
		/// </summary>
		public static List<tbl_securityFunctionMaster_Report_Advanced> SelectAllByCompanyBranch_ID(string companyBranch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionMaster_Report_AdvancedSelectAllByCompanyBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
				List<tbl_securityFunctionMaster_Report_Advanced> tbl_securityFunctionMaster_Report_AdvancedList = new List<tbl_securityFunctionMaster_Report_Advanced>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityFunctionMaster_Report_Advanced tbl_securityFunctionMaster_Report_Advanced = Maketbl_securityFunctionMaster_Report_Advanced(dataReader);
					tbl_securityFunctionMaster_Report_AdvancedList.Add(tbl_securityFunctionMaster_Report_Advanced);
				}
			}
			scon.Close();
			return tbl_securityFunctionMaster_Report_AdvancedList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_securityFunctionMaster_Report_Advanced class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_securityFunctionMaster_Report_Advanced Maketbl_securityFunctionMaster_Report_Advanced(SqlDataReader dataReader) {
			tbl_securityFunctionMaster_Report_Advanced tbl_securityFunctionMaster_Report_Advanced = new tbl_securityFunctionMaster_Report_Advanced();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_securityFunctionMaster_Report_Advanced.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_securityFunctionMaster_Report_Advanced.Function_ID = dataReader.GetInt32(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_securityFunctionMaster_Report_Advanced.CompanyID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_securityFunctionMaster_Report_Advanced.CompanyBranch_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_securityFunctionMaster_Report_Advanced.IsDefault = dataReader.GetBoolean(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_securityFunctionMaster_Report_Advanced.ReportPath = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_securityFunctionMaster_Report_Advanced.Remarks = dataReader.GetString(6);
			}

			return tbl_securityFunctionMaster_Report_Advanced;
		}
		/// <summary>
		/// This makes tbl_securityFunctionMaster_Report_Advanced datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_securityFunctionMaster_Report_Advanced object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_securityFunctionMaster_Report_Advanced  tbl_securityFunctionMaster_Report_Advanced   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_function_ID = new DataColumn("function_ID" , typeof(int));
			DataColumn col_companyID = new DataColumn("companyID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_isDefault = new DataColumn("isDefault" , typeof(bool));
			DataColumn col_reportPath = new DataColumn("reportPath" , typeof(string));
			DataColumn col_remarks = new DataColumn("remarks" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_function_ID,col_companyID,col_companyBranch_ID,col_isDefault,col_reportPath,col_remarks,});		return dt;
		}
		/// <summary>
		/// This fills tbl_securityFunctionMaster_Report_Advanced datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_securityFunctionMaster_Report_Advanced object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_securityFunctionMaster_Report_Advanced user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["function_ID"] = user.function_ID;
			drow["companyID"] = user.companyID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["isDefault"] = user.isDefault;
			drow["reportPath"] = user.reportPath;
			drow["remarks"] = user.remarks;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
