using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_cfgModule_Permission {
		#region Fields
		private string companyBranch_ID;
		private string user_ID;
		private int module_Index;
		private bool allowAccess;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_cfgModule_Permission class.
		/// </summary>
		public tbl_cfgModule_Permission() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_cfgModule_Permission class.
		/// </summary>
		public tbl_cfgModule_Permission(string companyBranch_ID, string user_ID, int module_Index, bool allowAccess) {
			this.companyBranch_ID = companyBranch_ID;
			this.user_ID = user_ID;
			this.module_Index = module_Index;
			this.allowAccess = allowAccess;
		}
		#endregion
		
		#region Properties
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
		/// Gets or sets the Module_Index value.
		/// </summary>
		public int Module_Index {
			get { return module_Index; }
			set { module_Index = value; }
		}
		
		/// <summary>
		/// Gets or sets the AllowAccess value.
		/// </summary>
		public bool AllowAccess {
			get { return allowAccess; }
			set { allowAccess = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_cfgModule_Permission table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_cfgModule_PermissionInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@module_Index", SqlDbType.Int,4);
			scom.Parameters.Add("@allowAccess", SqlDbType.Bit,1);
 
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@module_Index"].Value = module_Index;
			scom.Parameters["@allowAccess"].Value = allowAccess;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_cfgModule_Permission table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_cfgModule_PermissionUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@module_Index", SqlDbType.Int,4);
			scom.Parameters.Add("@allowAccess", SqlDbType.Bit,1);
 
 
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@module_Index"].Value = module_Index;
			scom.Parameters["@allowAccess"].Value = allowAccess;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_cfgModule_Permission table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_cfgModule_PermissionDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@module_Index", SqlDbType.Int,4);
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
			scom.Parameters["@user_ID"].Value = user_ID;
 
			scom.Parameters["@module_Index"].Value = module_Index;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_cfgModule_Permission table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyBranch_ID(string companyBranch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_cfgModule_PermissionDeleteAllByCompanyBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_cfgModule_Permission table by a foreign key.
		/// </summary>
		public static void DeleteAllByUser_ID(string user_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_cfgModule_PermissionDeleteAllByUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_cfgModule_Permission table by a foreign key.
		/// </summary>
		public static void DeleteAllByModule_Index(int module_Index) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_cfgModule_PermissionDeleteAllByModule_Index", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@module_Index", SqlDbType.Int,4);
			scom.Parameters["@module_Index"].Value = module_Index;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_cfgModule_Permission table.
		/// </summary>
		public static tbl_cfgModule_Permission Select(string companyBranch_ID_Incoming, string user_ID_Incoming, int module_Index_Incoming){

			tbl_cfgModule_Permission tbl_cfgModule_Permissionins = new tbl_cfgModule_Permission();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_cfgModule_PermissionSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@module_Index", SqlDbType.Int,4);
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID_Incoming;
			scom.Parameters["@user_ID"].Value = user_ID_Incoming;
			scom.Parameters["@module_Index"].Value = module_Index_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_cfgModule_Permissionins = Maketbl_cfgModule_Permission(dataReader);
				} else {
					tbl_cfgModule_Permissionins = null;
				}
			}
			scon.Close();
			return tbl_cfgModule_Permissionins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_cfgModule_Permission table.
		/// </summary>
		public static List<tbl_cfgModule_Permission> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_cfgModule_PermissionSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_cfgModule_Permission> tbl_cfgModule_PermissionList = new List<tbl_cfgModule_Permission>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_cfgModule_Permission tbl_cfgModule_Permission = Maketbl_cfgModule_Permission(dataReader);
					tbl_cfgModule_PermissionList.Add(tbl_cfgModule_Permission);
				}
			}
			scon.Close();
			return tbl_cfgModule_PermissionList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_cfgModule_Permission table by a foreign key.
		/// </summary>
		public static List<tbl_cfgModule_Permission> SelectAllByCompanyBranch_ID(string companyBranch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_cfgModule_PermissionSelectAllByCompanyBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
				List<tbl_cfgModule_Permission> tbl_cfgModule_PermissionList = new List<tbl_cfgModule_Permission>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_cfgModule_Permission tbl_cfgModule_Permission = Maketbl_cfgModule_Permission(dataReader);
					tbl_cfgModule_PermissionList.Add(tbl_cfgModule_Permission);
				}
			}
			scon.Close();
			return tbl_cfgModule_PermissionList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_cfgModule_Permission table by a foreign key.
		/// </summary>
		public static List<tbl_cfgModule_Permission> SelectAllByUser_ID(string user_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_cfgModule_PermissionSelectAllByUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID;
				List<tbl_cfgModule_Permission> tbl_cfgModule_PermissionList = new List<tbl_cfgModule_Permission>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_cfgModule_Permission tbl_cfgModule_Permission = Maketbl_cfgModule_Permission(dataReader);
					tbl_cfgModule_PermissionList.Add(tbl_cfgModule_Permission);
				}
			}
			scon.Close();
			return tbl_cfgModule_PermissionList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_cfgModule_Permission table by a foreign key.
		/// </summary>
		public static List<tbl_cfgModule_Permission> SelectAllByModule_Index(int module_Index) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_cfgModule_PermissionSelectAllByModule_Index", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@module_Index", SqlDbType.Int,4);
			scom.Parameters["@module_Index"].Value = module_Index;
				List<tbl_cfgModule_Permission> tbl_cfgModule_PermissionList = new List<tbl_cfgModule_Permission>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_cfgModule_Permission tbl_cfgModule_Permission = Maketbl_cfgModule_Permission(dataReader);
					tbl_cfgModule_PermissionList.Add(tbl_cfgModule_Permission);
				}
			}
			scon.Close();
			return tbl_cfgModule_PermissionList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_cfgModule_Permission class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_cfgModule_Permission Maketbl_cfgModule_Permission(SqlDataReader dataReader) {
			tbl_cfgModule_Permission tbl_cfgModule_Permission = new tbl_cfgModule_Permission();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_cfgModule_Permission.CompanyBranch_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_cfgModule_Permission.User_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_cfgModule_Permission.Module_Index = dataReader.GetInt32(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_cfgModule_Permission.AllowAccess = dataReader.GetBoolean(3);
			}

			return tbl_cfgModule_Permission;
		}
		/// <summary>
		/// This makes tbl_cfgModule_Permission datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_cfgModule_Permission object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_cfgModule_Permission  tbl_cfgModule_Permission   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_user_ID = new DataColumn("user_ID" , typeof(string));
			DataColumn col_module_Index = new DataColumn("module_Index" , typeof(int));
			DataColumn col_allowAccess = new DataColumn("allowAccess" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_companyBranch_ID,col_user_ID,col_module_Index,col_allowAccess,});		return dt;
		}
		/// <summary>
		/// This fills tbl_cfgModule_Permission datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_cfgModule_Permission object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_cfgModule_Permission user) {
		DataRow drow = dt.NewRow();
		
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["user_ID"] = user.user_ID;
			drow["module_Index"] = user.module_Index;
			drow["allowAccess"] = user.allowAccess;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
