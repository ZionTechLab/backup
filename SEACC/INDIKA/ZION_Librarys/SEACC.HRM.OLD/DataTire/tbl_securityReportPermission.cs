using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_securityReportPermission {
		#region Fields
		private string user_ID;
		private string report_ID;
		private bool allowPrint;
		private bool allowRePrint;
		private bool allowExport;
		private bool allowView;
		private bool isEnableDefaultPrinter;
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
		public tbl_securityReportPermission(string user_ID, string report_ID, bool allowPrint, bool allowRePrint, bool allowExport, bool allowView, bool isEnableDefaultPrinter) {
			this.user_ID = user_ID;
			this.report_ID = report_ID;
			this.allowPrint = allowPrint;
			this.allowRePrint = allowRePrint;
			this.allowExport = allowExport;
			this.allowView = allowView;
			this.isEnableDefaultPrinter = isEnableDefaultPrinter;
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
			scom.Parameters.Add("@allowPrint", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowRePrint", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowExport", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowView", SqlDbType.Bit,1);
			scom.Parameters.Add("@isEnableDefaultPrinter", SqlDbType.Bit,1);
 
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@report_ID"].Value = report_ID;
			scom.Parameters["@allowPrint"].Value = allowPrint;
			scom.Parameters["@allowRePrint"].Value = allowRePrint;
			scom.Parameters["@allowExport"].Value = allowExport;
			scom.Parameters["@allowView"].Value = allowView;
			scom.Parameters["@isEnableDefaultPrinter"].Value = isEnableDefaultPrinter;
 
 
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
			scom.Parameters.Add("@allowPrint", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowRePrint", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowExport", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowView", SqlDbType.Bit,1);
			scom.Parameters.Add("@isEnableDefaultPrinter", SqlDbType.Bit,1);
 
 
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@report_ID"].Value = report_ID;
			scom.Parameters["@allowPrint"].Value = allowPrint;
			scom.Parameters["@allowRePrint"].Value = allowRePrint;
			scom.Parameters["@allowExport"].Value = allowExport;
			scom.Parameters["@allowView"].Value = allowView;
			scom.Parameters["@isEnableDefaultPrinter"].Value = isEnableDefaultPrinter;
 
 
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
			scom.Parameters["@user_ID"].Value = user_ID;
 
			scom.Parameters["@report_ID"].Value = report_ID;
 
 
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
		public static tbl_securityReportPermission Select(string user_ID_Incoming, string report_ID_Incoming){

			tbl_securityReportPermission tbl_securityReportPermissionins = new tbl_securityReportPermission();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityReportPermissionSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@report_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID_Incoming;
			scom.Parameters["@report_ID"].Value = report_ID_Incoming;
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
				tbl_securityReportPermission.AllowPrint = dataReader.GetBoolean(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_securityReportPermission.AllowRePrint = dataReader.GetBoolean(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_securityReportPermission.AllowExport = dataReader.GetBoolean(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_securityReportPermission.AllowView = dataReader.GetBoolean(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_securityReportPermission.IsEnableDefaultPrinter = dataReader.GetBoolean(6);
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
			DataColumn col_allowPrint = new DataColumn("allowPrint" , typeof(bool));
			DataColumn col_allowRePrint = new DataColumn("allowRePrint" , typeof(bool));
			DataColumn col_allowExport = new DataColumn("allowExport" , typeof(bool));
			DataColumn col_allowView = new DataColumn("allowView" , typeof(bool));
			DataColumn col_isEnableDefaultPrinter = new DataColumn("isEnableDefaultPrinter" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_user_ID,col_report_ID,col_allowPrint,col_allowRePrint,col_allowExport,col_allowView,col_isEnableDefaultPrinter,});		return dt;
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
			drow["allowPrint"] = user.allowPrint;
			drow["allowRePrint"] = user.allowRePrint;
			drow["allowExport"] = user.allowExport;
			drow["allowView"] = user.allowView;
			drow["isEnableDefaultPrinter"] = user.isEnableDefaultPrinter;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
