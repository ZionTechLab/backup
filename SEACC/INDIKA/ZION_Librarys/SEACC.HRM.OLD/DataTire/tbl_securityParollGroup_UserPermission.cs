using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_securityParollGroup_UserPermission {
		#region Fields
		private string company_ID;
		private string companyBranch_ID;
		private string user_ID;
		private string processGroup_ID;
		private bool allowView;
		private bool allowSave;
		private bool allowEdit;
		private bool allowRollback;
		private bool allowCheckable;
		private bool allowApprovable;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_securityParollGroup_UserPermission class.
		/// </summary>
		public tbl_securityParollGroup_UserPermission() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_securityParollGroup_UserPermission class.
		/// </summary>
		public tbl_securityParollGroup_UserPermission(string company_ID, string companyBranch_ID, string user_ID, string processGroup_ID, bool allowView, bool allowSave, bool allowEdit, bool allowRollback, bool allowCheckable, bool allowApprovable) {
			this.company_ID = company_ID;
			this.companyBranch_ID = companyBranch_ID;
			this.user_ID = user_ID;
			this.processGroup_ID = processGroup_ID;
			this.allowView = allowView;
			this.allowSave = allowSave;
			this.allowEdit = allowEdit;
			this.allowRollback = allowRollback;
			this.allowCheckable = allowCheckable;
			this.allowApprovable = allowApprovable;
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
		/// Gets or sets the User_ID value.
		/// </summary>
		public string User_ID {
			get { return user_ID; }
			set { user_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProcessGroup_ID value.
		/// </summary>
		public string ProcessGroup_ID {
			get { return processGroup_ID; }
			set { processGroup_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the AllowView value.
		/// </summary>
		public bool AllowView {
			get { return allowView; }
			set { allowView = value; }
		}
		
		/// <summary>
		/// Gets or sets the AllowSave value.
		/// </summary>
		public bool AllowSave {
			get { return allowSave; }
			set { allowSave = value; }
		}
		
		/// <summary>
		/// Gets or sets the AllowEdit value.
		/// </summary>
		public bool AllowEdit {
			get { return allowEdit; }
			set { allowEdit = value; }
		}
		
		/// <summary>
		/// Gets or sets the AllowRollback value.
		/// </summary>
		public bool AllowRollback {
			get { return allowRollback; }
			set { allowRollback = value; }
		}
		
		/// <summary>
		/// Gets or sets the AllowCheckable value.
		/// </summary>
		public bool AllowCheckable {
			get { return allowCheckable; }
			set { allowCheckable = value; }
		}
		
		/// <summary>
		/// Gets or sets the AllowApprovable value.
		/// </summary>
		public bool AllowApprovable {
			get { return allowApprovable; }
			set { allowApprovable = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_securityParollGroup_UserPermission table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityParollGroup_UserPermissionInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@processGroup_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@allowView", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowSave", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowEdit", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowRollback", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowCheckable", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowApprovable", SqlDbType.Bit,1);
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@processGroup_ID"].Value = processGroup_ID;
			scom.Parameters["@allowView"].Value = allowView;
			scom.Parameters["@allowSave"].Value = allowSave;
			scom.Parameters["@allowEdit"].Value = allowEdit;
			scom.Parameters["@allowRollback"].Value = allowRollback;
			scom.Parameters["@allowCheckable"].Value = allowCheckable;
			scom.Parameters["@allowApprovable"].Value = allowApprovable;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_securityParollGroup_UserPermission table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityParollGroup_UserPermissionUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@processGroup_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@allowView", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowSave", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowEdit", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowRollback", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowCheckable", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowApprovable", SqlDbType.Bit,1);
 
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@processGroup_ID"].Value = processGroup_ID;
			scom.Parameters["@allowView"].Value = allowView;
			scom.Parameters["@allowSave"].Value = allowSave;
			scom.Parameters["@allowEdit"].Value = allowEdit;
			scom.Parameters["@allowRollback"].Value = allowRollback;
			scom.Parameters["@allowCheckable"].Value = allowCheckable;
			scom.Parameters["@allowApprovable"].Value = allowApprovable;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_securityParollGroup_UserPermission table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityParollGroup_UserPermissionDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@processGroup_ID", SqlDbType.VarChar,10);
			scom.Parameters["@company_ID"].Value = company_ID;
 
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
			scom.Parameters["@user_ID"].Value = user_ID;
 
			scom.Parameters["@processGroup_ID"].Value = processGroup_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityParollGroup_UserPermission table by a foreign key.
		/// </summary>
		public static void DeleteAllByUser_ID(string user_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityParollGroup_UserPermissionDeleteAllByUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityParollGroup_UserPermission table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompany_ID_CompanyBranch_ID_ProcessGroup_ID(string company_ID, string companyBranch_ID, string processGroup_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityParollGroup_UserPermissionDeleteAllByCompany_ID_CompanyBranch_ID_ProcessGroup_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@processGroup_ID", SqlDbType.VarChar,10);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@processGroup_ID"].Value = processGroup_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_securityParollGroup_UserPermission table.
		/// </summary>
		public static tbl_securityParollGroup_UserPermission Select(string company_ID_Incoming, string companyBranch_ID_Incoming, string user_ID_Incoming, string processGroup_ID_Incoming){

			tbl_securityParollGroup_UserPermission tbl_securityParollGroup_UserPermissionins = new tbl_securityParollGroup_UserPermission();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityParollGroup_UserPermissionSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@processGroup_ID", SqlDbType.VarChar,10);
			scom.Parameters["@company_ID"].Value = company_ID_Incoming;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID_Incoming;
			scom.Parameters["@user_ID"].Value = user_ID_Incoming;
			scom.Parameters["@processGroup_ID"].Value = processGroup_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_securityParollGroup_UserPermissionins = Maketbl_securityParollGroup_UserPermission(dataReader);
				} else {
					tbl_securityParollGroup_UserPermissionins = null;
				}
			}
			scon.Close();
			return tbl_securityParollGroup_UserPermissionins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityParollGroup_UserPermission table.
		/// </summary>
		public static List<tbl_securityParollGroup_UserPermission> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityParollGroup_UserPermissionSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_securityParollGroup_UserPermission> tbl_securityParollGroup_UserPermissionList = new List<tbl_securityParollGroup_UserPermission>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityParollGroup_UserPermission tbl_securityParollGroup_UserPermission = Maketbl_securityParollGroup_UserPermission(dataReader);
					tbl_securityParollGroup_UserPermissionList.Add(tbl_securityParollGroup_UserPermission);
				}
			}
			scon.Close();
			return tbl_securityParollGroup_UserPermissionList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityParollGroup_UserPermission table by a foreign key.
		/// </summary>
		public static List<tbl_securityParollGroup_UserPermission> SelectAllByUser_ID(string user_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityParollGroup_UserPermissionSelectAllByUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID;
				List<tbl_securityParollGroup_UserPermission> tbl_securityParollGroup_UserPermissionList = new List<tbl_securityParollGroup_UserPermission>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityParollGroup_UserPermission tbl_securityParollGroup_UserPermission = Maketbl_securityParollGroup_UserPermission(dataReader);
					tbl_securityParollGroup_UserPermissionList.Add(tbl_securityParollGroup_UserPermission);
				}
			}
			scon.Close();
			return tbl_securityParollGroup_UserPermissionList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityParollGroup_UserPermission table by a foreign key.
		/// </summary>
		public static List<tbl_securityParollGroup_UserPermission> SelectAllByCompany_ID_CompanyBranch_ID_ProcessGroup_ID(string company_ID, string companyBranch_ID, string processGroup_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityParollGroup_UserPermissionSelectAllByCompany_ID_CompanyBranch_ID_ProcessGroup_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@processGroup_ID", SqlDbType.VarChar,10);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@processGroup_ID"].Value = processGroup_ID;
				List<tbl_securityParollGroup_UserPermission> tbl_securityParollGroup_UserPermissionList = new List<tbl_securityParollGroup_UserPermission>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityParollGroup_UserPermission tbl_securityParollGroup_UserPermission = Maketbl_securityParollGroup_UserPermission(dataReader);
					tbl_securityParollGroup_UserPermissionList.Add(tbl_securityParollGroup_UserPermission);
				}
			}
			scon.Close();
			return tbl_securityParollGroup_UserPermissionList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_securityParollGroup_UserPermission class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_securityParollGroup_UserPermission Maketbl_securityParollGroup_UserPermission(SqlDataReader dataReader) {
			tbl_securityParollGroup_UserPermission tbl_securityParollGroup_UserPermission = new tbl_securityParollGroup_UserPermission();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_securityParollGroup_UserPermission.Company_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_securityParollGroup_UserPermission.CompanyBranch_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_securityParollGroup_UserPermission.User_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_securityParollGroup_UserPermission.ProcessGroup_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_securityParollGroup_UserPermission.AllowView = dataReader.GetBoolean(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_securityParollGroup_UserPermission.AllowSave = dataReader.GetBoolean(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_securityParollGroup_UserPermission.AllowEdit = dataReader.GetBoolean(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_securityParollGroup_UserPermission.AllowRollback = dataReader.GetBoolean(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_securityParollGroup_UserPermission.AllowCheckable = dataReader.GetBoolean(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_securityParollGroup_UserPermission.AllowApprovable = dataReader.GetBoolean(9);
			}

			return tbl_securityParollGroup_UserPermission;
		}
		/// <summary>
		/// This makes tbl_securityParollGroup_UserPermission datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_securityParollGroup_UserPermission object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_securityParollGroup_UserPermission  tbl_securityParollGroup_UserPermission   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_company_ID = new DataColumn("company_ID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_user_ID = new DataColumn("user_ID" , typeof(string));
			DataColumn col_processGroup_ID = new DataColumn("processGroup_ID" , typeof(string));
			DataColumn col_allowView = new DataColumn("allowView" , typeof(bool));
			DataColumn col_allowSave = new DataColumn("allowSave" , typeof(bool));
			DataColumn col_allowEdit = new DataColumn("allowEdit" , typeof(bool));
			DataColumn col_allowRollback = new DataColumn("allowRollback" , typeof(bool));
			DataColumn col_allowCheckable = new DataColumn("allowCheckable" , typeof(bool));
			DataColumn col_allowApprovable = new DataColumn("allowApprovable" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_company_ID,col_companyBranch_ID,col_user_ID,col_processGroup_ID,col_allowView,col_allowSave,col_allowEdit,col_allowRollback,col_allowCheckable,col_allowApprovable,});		return dt;
		}
		/// <summary>
		/// This fills tbl_securityParollGroup_UserPermission datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_securityParollGroup_UserPermission object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_securityParollGroup_UserPermission user) {
		DataRow drow = dt.NewRow();
		
			drow["company_ID"] = user.company_ID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["user_ID"] = user.user_ID;
			drow["processGroup_ID"] = user.processGroup_ID;
			drow["allowView"] = user.allowView;
			drow["allowSave"] = user.allowSave;
			drow["allowEdit"] = user.allowEdit;
			drow["allowRollback"] = user.allowRollback;
			drow["allowCheckable"] = user.allowCheckable;
			drow["allowApprovable"] = user.allowApprovable;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
